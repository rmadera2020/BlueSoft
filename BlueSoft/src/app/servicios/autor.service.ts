import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Autor }from '../models/Autor';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = 'https://localhost:44364/';
      this.myApiUrl = 'api/Autores/';
  }

  getAutores(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getAutor(idAutor: number): Observable<Autor> {
      return this.http.get<Autor>(this.myAppUrl + this.myApiUrl + idAutor)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveAutor(autor): Observable<Autor> {
      return this.http.post<Autor>(this.myAppUrl + this.myApiUrl, JSON.stringify(autor), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateAutor(idAutor: number, autor): Observable<Autor> {
     alert(this.myAppUrl + this.myApiUrl + idAutor);
     alert(JSON.stringify(autor));
     
      return this.http.put<Autor>(this.myAppUrl + this.myApiUrl + idAutor, JSON.stringify(autor), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteAutor(idAutor: number): Observable<Autor> {
      return this.http.delete<Autor>(this.myAppUrl + this.myApiUrl + idAutor)
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
