import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AutorService } from '../servicios/autor.service';
import { Autor } from '../models/autor';


@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styles: ['/autores.component.css']
})
export class AutoresComponent implements OnInit {

  autores$: Observable<Autor[]>;

  constructor(private autorService: AutorService) {
  }

  ngOnInit() {
    this.loadAutores();
  }

  loadAutores() {
    this.autores$ = this.autorService.getAutores();
  }

  delete(idCategoria) {
    const ans = confirm('Esta seguro que desea eliminar este autor: ' + idCategoria);
    if (ans) {
      this.autorService.deleteAutor(idCategoria).subscribe((data) => {
        this.loadAutores();
      });
    }
  }

}
