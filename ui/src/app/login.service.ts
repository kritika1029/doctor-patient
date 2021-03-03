import { HttpClient } from '@angular/common/http';
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
}
