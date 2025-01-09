import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import { map } from 'rxjs/operators';
import {Music} from '../classes/music';


@Injectable({
  providedIn: 'root'
})
export class VoteService {
  private apiUrl = 'http://localhost:5260/api/votes';

  constructor(private http: HttpClient) { }

  createVote(userId: number, musicId: number): Observable<void> {
    const vote = { userId: userId, musicId: musicId };
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<void>(this.apiUrl, vote, httpOptions).pipe(
      catchError((error) => {
        if(error.status === 500) {
          console.log(error.error.message);
          return throwError(() => ({message: error.error.message || 'Internal server error.'}));
        }
        return throwError(() => error.error);
      })
    )
  }

  getVoteCount(musicId: number | undefined): Observable<{ voteCount: number }> {
    return this.http.get<{ voteCount: number }>(`${this.apiUrl}/${musicId}`);
  }
}
