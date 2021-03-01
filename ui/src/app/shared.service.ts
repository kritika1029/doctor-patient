import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:49907/api";
  readonly PhotoUrl = "http://localhost:49907/Photos";

  constructor(private http: HttpClient) { }

  docLogin(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Doctor/login', val);
  }

  updateDoc(val: any): Observable<any> {
    return this.http.put<any>(this.APIUrl + '/Doctor', val);
  }

  addDoc(val: any): Observable<any> {
    return this.http.post<any>(this.APIUrl + '/Doctor', val);
  }

  getDocById(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Doctor/id', val);
  }

  getDocByField(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Doctor/field', val);
  }

  getFieldList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Doctor/fieldlist');
  }

  patientLogin(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Patient/login', val);
  }

  updatePatient(val: any): Observable<any> {
    return this.http.put<any>(this.APIUrl + '/Patient', val);
  }

  addPatient(val: any): Observable<any> {
    return this.http.post<any>(this.APIUrl + '/Patient', val);
  }

  getPatientById(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Patient/id', val);
  }

  getPatientByRoomNumber(val: any): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Patient/roomnumber', val);
  }

  uploadPrescription(val: any) {
    return this.http.post(this.APIUrl + '/Patient/prescription', val);
  }

  uploadDocPic(val: any) {
    return this.http.post(this.APIUrl + '/Doctor/DocPic', val);
  }
}
