import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//Autores
import { AutoresComponent } from './autores/autores.component';
import { AutorComponent } from './autor/autor.component';
import { AutorAddeditComponent } from './autor-addedit/autor-addedit.component';

//Categorias
import { CategoriasComponent } from './categorias/categorias.component';
import { CategoriaComponent } from './categoria/categoria.component';
import { CategoriaAddeditComponent } from './categoria-addedit/categoria-addedit.component';

//Libros
import { LibrosComponent } from './libros/libros.component';
import { LibroComponent } from './libro/libro.component';
import { LibroAddeditComponent } from './libro-addedit/libro-addedit.component';



const routes: Routes = [
  { path: 'autores', component: AutoresComponent},
  { path: 'autor/:id', component: AutorComponent },
  { path: 'autor/add', component: AutorAddeditComponent },
  { path: 'autor/edit/:id', component: AutorAddeditComponent },

  { path: 'categorias', component: CategoriasComponent},
  { path: 'categoria/:id', component: CategoriaComponent },
  { path: 'categoria/add', component: CategoriaAddeditComponent },
  { path: 'categoria/edit/:id', component: CategoriaAddeditComponent },

  { path: 'libros', component: LibrosComponent},
  { path: 'libro/:id', component: LibroComponent },
  { path: 'libro/add', component: LibroAddeditComponent },
  { path: 'libro/edit/:id', component: LibroAddeditComponent },
  { path: '**', redirectTo: '/' }
];


//const routes: Routes = [
//  { path: '', component: CategoriasComponent, pathMatch: 'full' },
//  { path: 'categoria/:id', component: CategoriaComponent },
//  { path: 'add', component: CategoriaAddeditComponent },
//  { path: 'categoria/edit/:id', component: CategoriaAddeditComponent },
 // { path: '**', redirectTo: '/' }
//];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
