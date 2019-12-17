import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Libro } from '../models/libro';


@Injectable({
  providedIn: 'root'
})
export class LibroService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = 'https://localhost:44364/';
      this.myApiUrl = 'api/Libros/';
  }

  getLibros(): Observable<Libro[]> {
    return this.http.get<Libro[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getLibro(idLibro: number): Observable<Libro> {
      return this.http.get<Libro>(this.myAppUrl + this.myApiUrl + idLibro)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveLibro(libro): Observable<Libro> {
      return this.http.post<Libro>(this.myAppUrl + this.myApiUrl, JSON.stringify(libro), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateLibro(idLibro: number, libro): Observable<Libro> {
      return this.http.put<Libro>(this.myAppUrl + this.myApiUrl + idLibro, JSON.stringify(libro), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteLibro(idLibro: number): Observable<Libro> {
      return this.http.delete<Libro>(this.myAppUrl + this.myApiUrl + idLibro)
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
