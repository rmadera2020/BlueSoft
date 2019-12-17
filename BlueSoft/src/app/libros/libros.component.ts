import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LibroService } from '../servicios/libro.service';
import { Libro } from '../models/libro';
@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})
export class LibrosComponent implements OnInit {

  libros$: Observable<Libro[]>;

  constructor(private libroService: LibroService) {
  }

  ngOnInit() {
    this.loadLibros();
  }

  loadLibros() {
    this.libros$ = this.libroService.getLibros();
  }

  delete(idLibro) {
    const ans = confirm('Esta seguro que desea eliminar este libro: ' + idLibro);
    if (ans) {
      this.libroService.deleteLibro(idLibro).subscribe((data) => {
        this.loadLibros();
      });
    }
  }

}
