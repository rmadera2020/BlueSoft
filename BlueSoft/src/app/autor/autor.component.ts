import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AutorService } from '../servicios/autor.service';
import { Autor } from '../models/autor';
@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styles: []
})
export class AutorComponent implements OnInit {

  autor$: Observable<Autor>;
  idAutor: number;

  constructor(private autorService: AutorService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.idAutor = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadBlogPost();
  }

  loadBlogPost() {
    this.autor$ = this.autorService.getAutor(this.idAutor);
  }

}
