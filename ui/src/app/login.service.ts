import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDoctor } from 'src/app/doctor';
import { doctordb } from 'src/app/doctordb';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private _url:string="/assets/data/doctor.json";

  constructor(private http:HttpClient) { }

  getDoctor():Observable<IDoctor[]>{
    return this.http.get<IDoctor[]>(this._url);
  }

  private APIUrl: string = "http://localhost:49907/api/doctor/";
  readonly PhotoUrl = "http://localhost:49907/Photos";

  docLogin(): Observable<any> {
    let params1 = new HttpParams()
      .set('email', "rsinghal@gmail.com")
      .set('password', "123");

    return this.http.get(this.APIUrl, { params:params1 });
  }
}
