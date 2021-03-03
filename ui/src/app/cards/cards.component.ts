import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service'
import { LoginService } from '../login.service';
import { doctordb } from 'src/app/doctordb';

@Component({
  selector: 'cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  public details: import("src/app/doctordb").doctordb[] | undefined;
  
  

  constructor(private _services:LoginService) { 

  }

  form = new FormGroup({
    DocEmail:new FormControl('',Validators.required),
    DocPassword:new FormControl('',Validators.required),
  });

 
  get DocEmail()
      {
        return this.form.get('uname');
      }
  get DocPassword()
      {
        return this.form.get('psw');
      }

  public val:doctordb[] = [{
    DocID: 0,
    DocName: "",
    DocField: "",
    DocMobile: "",
    DocEmail: "rsinghal@gmail.com",
    DocPassword: "123",
    DateOfJoinig: "",
    DocPicName: ""
  }]

  ngOnInit() {
    this._services.docLogin()
      .subscribe(data => this.details = data);
  }

  submit(form1 :{value:any;}) {
    console.log(form1.value);
    console.log(this.details)
  }

}
