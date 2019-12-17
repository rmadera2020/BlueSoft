import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoriaService } from '../servicios/categoria.service';
import { Categoria } from '../models/categoria';


@Component({
  selector: 'app-categoria-addedit',
  templateUrl: './categoria-addedit.component.html',
  styles: []
})
export class CategoriaAddeditComponent implements OnInit {

  form: FormGroup;
  actionType: string;
  formNombre: string;
  formDescripcion: string;
  idCategoria: number;
  errorMessage: any;
  existingCategoria: Categoria;

  constructor(private categoriaService: CategoriaService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formNombre = 'nombre';
    this.formDescripcion = 'descripcion';
    if (this.avRoute.snapshot.params[idParam]) {
      this.idCategoria = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        idCategoria: 0,
        nombre: ['', [Validators.required]],
        descripcion: ['', [Validators.required]],
      }
    )
  }

  ngOnInit() {

    if (this.idCategoria > 0) {
      this.actionType = 'Edit';
      this.categoriaService.getCategoria(this.idCategoria)
        .subscribe(data => (
          this.existingCategoria = data,
          this.form.controls[this.formNombre].setValue(data.nombre),
          this.form.controls[this.formDescripcion].setValue(data.descripcion)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let categoria: Categoria = {
        nombre: this.form.get(this.formNombre).value,
        descripcion: this.form.get(this.formDescripcion).value
      };

      this.categoriaService.saveCategoria(categoria)
        .subscribe((data) => {
          this.router.navigate(['/categoria', data.idCategoria]);
        });
    }

    if (this.actionType === 'Edit') {
      let categoria: Categoria = {
        idCategoria: this.existingCategoria.idCategoria,
        nombre: this.form.get(this.formNombre).value,
        descripcion: this.form.get(this.formDescripcion).value
      };
      this.categoriaService.updateCategoria(categoria.idCategoria, categoria)
        .subscribe((data) => {
          this.router.navigate(['/categorias']);
        });
    }
  }

  cancel() {
    this.router.navigate(['/categorias']);
  }

  get nombre() { return this.form.get(this.formNombre); }
  get descripcion() { return this.form.get(this.formDescripcion); }

}
