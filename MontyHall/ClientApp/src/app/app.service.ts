import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { SimulationParameters, SimulationResult } from './app.model';

@Injectable()
export class AppService {
  
  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) {
  }

  public execute(parameters: SimulationParameters): Observable<SimulationResult> {
    return this.http.post(this.baseUrl + 'api/simulation/execute', parameters)
      .pipe(
        map(response => <SimulationResult>response),
        catchError((error) => {
          console.log(error);
          return of(undefined);
        })
      );
  }
}
