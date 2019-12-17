import { Autor } from './Autor';
import { Categoria } from './categoria';

export class Libro {
    idLibro?: number;
    nombre: string;
    idAutor: number;
    idCategoria: number;
    ISBN: string;
    autor: Autor;
    categoria: Categoria;
  }