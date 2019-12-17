import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Categoria } from '../models/categoria';



@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  myAppUrl: string;
  myApiUrl: string;
  //https://localhost:44364/api/Categorias
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = 'https://localhost:44364/';
      this.myApiUrl = 'api/Categorias/';
  }

  getCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getCategoria(idCategoria: number): Observable<Categoria> {
      return this.http.get<Categoria>(this.myAppUrl + this.myApiUrl + idCategoria)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveCategoria(categoria): Observable<Categoria> {
      return this.http.post<Categoria>(this.myAppUrl + this.myApiUrl, JSON.stringify(categoria), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateCategoria(idCategoria: number, categoria): Observable<Categoria> {
      return this.http.put<Categoria>(this.myAppUrl + this.myApiUrl + idCategoria, JSON.stringify(categoria), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteCategoria(idCategoria: number): Observable<Categoria> {
      return this.http.delete<Categoria>(this.myAppUrl + this.myApiUrl + idCategoria)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {      
      errorMessage = error.error.message;
    } else {      
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
