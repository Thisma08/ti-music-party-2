import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {Music} from '../classes/music';

@Injectable({
  providedIn: 'root'
})
export class MusicService {
  private apiUrl = 'http://localhost:5000/api/musics';

  constructor(private http: HttpClient) {}

  fetchAllMusics(): Observable<Music[]> {
    return this.http.get<Music[]>(this.apiUrl);
  }

  fetchTop10(): Observable<Music[]> {
    return this.http.get<Music[]>(`${this.apiUrl}/top10`);
  }

  createMusic(music: any): Observable<any> {
    return this.http.post(this.apiUrl, music).pipe(
      catchError((error) => {
        if(error.status === 409) {
          console.log(error.error.message);
          return throwError(() => ({message: error.error.message || 'Conflict error.'}));
        }
        return throwError(() => error.error);
      })
    );
  }

  deleteMusic(id: number | undefined): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
