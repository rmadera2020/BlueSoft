
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AutoresComponent } from './autores/autores.component';
import { AutorComponent } from './autor/autor.component';
import { AutorAddeditComponent } from './autor-addedit/autor-addedit.component';
import { AutorService }from './servicios/autor.service';
import { CategoriasComponent } from './categorias/categorias.component';
import { CategoriaComponent } from './categoria/categoria.component';
import { CategoriaAddeditComponent } from './categoria-addedit/categoria-addedit.component';
import { CategoriaService }from './servicios/categoria.service';
import { LibrosComponent } from './libros/libros.component';
import { LibroComponent } from './libro/libro.component';
import { LibroAddeditComponent } from './libro-addedit/libro-addedit.component';
import { LibroService } from './servicios/libro.service';

@NgModule({
  declarations: [
    AppComponent,
    AutoresComponent,
    AutorComponent,
    AutorAddeditComponent,
    CategoriasComponent,    
    CategoriaComponent,
    CategoriaAddeditComponent,
    LibrosComponent,
    LibroComponent,
    LibroAddeditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [AutorService, CategoriaService, LibroService],
  bootstrap: [AppComponent]
})
export class AppModule { }
