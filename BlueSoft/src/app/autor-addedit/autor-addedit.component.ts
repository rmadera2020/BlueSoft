import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AutorService } from '../servicios/autor.service';
import { Autor } from '../models/autor';
@Component({
  selector: 'app-autor-addedit',
  templateUrl: './autor-addedit.component.html',
  styles: []
})
export class AutorAddeditComponent implements OnInit {

  form: FormGroup;
  actionType: string;
  
  formNombre: string;
  formApellidos: string;
  formFechaNac: string;
  idAutor: number;
  
  errorMessage: any;
  existingAutor: Autor;

  constructor(private autorService: AutorService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    
    const idParam = 'id';

    this.actionType = 'Add';
    this.formNombre = 'nombre';
    this.formApellidos = 'apellidos';
    this.formFechaNac = 'fechanac';
    this.idAutor = 0;

    if (this.avRoute.snapshot.params[idParam]) {
      this.idAutor = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        idAutor: 0,
        nombre: ['', [Validators.required]],
        apellidos: ['', [Validators.required]],
        fechanac: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {
    
    if (this.idAutor > 0) {
      this.actionType = 'Edit';
      this.autorService.getAutor(this.idAutor)
        .subscribe(data => (
          this.existingAutor = data,          
          this.form.controls[this.formNombre].setValue(data.nombre),
          this.form.controls[this.formApellidos].setValue(data.apellidos),
          this.form.controls[this.formFechaNac].setValue(data.fechanac)
        ));
       
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }
    
    if (this.actionType === 'Add') {
      
      let autor: Autor = {
        nombre: this.form.get(this.formNombre).value,
        apellidos: this.form.get(this.formApellidos).value,
        fechanac:  this.form.get(this.formFechaNac).value   
      };
      alert(autor);
      this.autorService.saveAutor(autor)
        .subscribe((data) => {
          this.router.navigate(['/autor', data.idAutor]);
        });
    }

    if (this.actionType === 'Edit') {
      
      let autor: Autor = {
        idAutor: this.existingAutor.idAutor,              
        nombre: this.form.get(this.formNombre).value,
        apellidos: this.form.get(this.formApellidos).value,
        fechanac: this.form.get(this.formFechaNac).value 
      };
      this.autorService.updateAutor(autor.idAutor, autor)
        .subscribe((data) => {
          this.router.navigate(['/autores']);
        });
    }
  }

  cancel() {
    this.router.navigate(['/autores']);
  }
  
  get nombre() { return this.form.get(this.formNombre); }
  get apellidos() { return this.form.get(this.formApellidos); }
  get fechanac() { return this.form.get(this.formFechaNac); }

}
