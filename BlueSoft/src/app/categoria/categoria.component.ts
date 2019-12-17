import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriaService } from '../servicios/categoria.service';
import { Categoria } from '../models/categoria';



@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styles: []
})
export class CategoriaComponent implements OnInit {

  categoria$: Observable<Categoria>;
  idCategoria: number;

  constructor(private categoriaService: CategoriaService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.idCategoria = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadCategoria();
  }

  loadCategoria() {
    this.categoria$ = this.categoriaService.getCategoria(this.idCategoria);
  }

}
