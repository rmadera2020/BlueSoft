import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriaService } from '../servicios/categoria.service';
import { Categoria } from '../models/categoria';


@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  categorias$: Observable<Categoria[]>;

  constructor(private categoriaService: CategoriaService) {
  }

  ngOnInit() {
    this.loadCategorias();
  }

  loadCategorias() {
    this.categorias$ = this.categoriaService.getCategorias();
  }

  delete(idCategoria) {
    const ans = confirm('Esta seguro que desea eliminar esta categoria ?  ' + idCategoria);
    if (ans) {
      this.categoriaService.deleteCategoria(idCategoria).subscribe((data) => {
        this.loadCategorias();
      });
    }
  }
}
