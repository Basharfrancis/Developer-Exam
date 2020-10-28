import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Month } from './api';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';




@Injectable()
export class ApiService {
    private heroesUrl = 'http://habib.signalsy.net/api/User/GetList';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
    constructor(private http: HttpClient) {}
  

      /**
       * 
       * @param month 
       * usere page load all cars information with price and
       *  type and color basied on the month that user request for
       */
    getAllCars(month: Month): Observable<Month> {
        console.log("heresdaaaaaaaaaaaaa", month, this.heroesUrl, "url")
        return this.http.post<Month>(this.heroesUrl, month).pipe(
            
          catchError(this.handleError<Month>('getAllCars'))
        )
      }
      private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
          // TODO: send the error to remote logging infrastructure
          console.error(error); // log to console instead
    
          // TODO: better job of transforming error for user consumption
        //   this.log(`${operation} failed: ${error.message}`);
    
          // Let the app keep running by returning an empty result.
          return of(result as T);
        };
      }

}
// import { Injectable } from '@angular/core';
// import { HttpClient, HttpHeaders } from '@angular/common/http';

// import { Observable, of } from 'rxjs';
// import { catchError, map, tap } from 'rxjs/operators';

// import { Hero } from './hero';



// @Injectable({
//   providedIn: 'root'
// })
// export class HeroService {
//   private heroesUrl = 'api/heroes';

//   httpOptions = {
//     headers: new HttpHeaders({ 'Content-Type': 'application/json' })
//   };

//   constructor(private http: HttpClient) { }

//     /** GET heroes from the server */
//     getHeroes(): Observable<Hero[]> {
//       return this.http.get<Hero[]>(this.heroesUrl)
//         .pipe(
//           catchError(this.handleError<Hero[]>('getHeroes', []))
//         );
//     }

//       /** GET hero by id. Return `undefined` when id not found */
//   getHeroNo404<Data>(id: number): Observable<Hero> {
//     const url = `${this.heroesUrl}/?id=${id}`;
//     return this.http.get<Hero[]>(url)
//       .pipe(
//         map(heroes => heroes[0]), // returns a {0|1} element array
//         tap(h => {
//           const outcome = h ? `fetched` : `did not find`;
//         }),
//         catchError(this.handleError<Hero>(`getHero id=${id}`))
//       );
//   }

//    /** GET hero by id. Will 404 if id not found */
//    getHero(id: number): Observable<Hero> {
//     const url = `${this.heroesUrl}/${id}`;
//     return this.http.get<Hero>(url).pipe(
//       catchError(this.handleError<Hero>(`getHero id=${id}`))
//     );
//   }


//   /* GET heroes whose name contains search term */
//   searchHeroes(term: string): Observable<Hero[]> {
//     if (!term.trim()) {
//       // if not search term, return empty hero array.
//       return of([]);
//     }
//     return this.http.get<Hero[]>(`${this.heroesUrl}/?name=${term}`).pipe(
//       catchError(this.handleError<Hero[]>('searchHeroes', []))
//     );
//   }


//    /** POST: add a new hero to the server */
//    addHero(hero: Hero): Observable<Hero> {
//     return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions).pipe(
//       catchError(this.handleError<Hero>('addHero'))
//     );
//   }

//   /** DELETE: delete the hero from the server */
//   deleteHero(hero: Hero | number): Observable<Hero> {
//     const id = typeof hero === 'number' ? hero : hero.id;
//     const url = `${this.heroesUrl}/${id}`;

//     return this.http.delete<Hero>(url, this.httpOptions).pipe(
//       catchError(this.handleError<Hero>('deleteHero'))
//     );
//   }

//   /** PUT: update the hero on the server */
//   updateHero(hero: Hero): Observable<any> {
//     return this.http.put(this.heroesUrl, hero, this.httpOptions).pipe(
//       catchError(this.handleError<any>('updateHero'))
//     );
//   }

//   private handleError<T>(operation = 'operation', result?: T) {
//     return (error: any): Observable<T> => {

//       // TODO: send the error to remote logging infrastructure
//       console.error(error); // log to console instead

//       // TODO: better job of transforming error for user consumption

//       // Let the app keep running by returning an empty result.
//       return of(result as T);
//     };
//   }


// }
