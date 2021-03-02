import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service'
import { LoginService } from '../login.service';
@Component({
  selector: 'cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  public details: import("c:/Users/kritiaro/angular/doctor/ui/src/app/doctor").IDoctor[] | undefined;
  
  

  constructor(private _services:LoginService) { 

  }

  form=new FormGroup({
    uname:new FormControl('',Validators.required),
    psw:new FormControl('',Validators.required),
 });
 
 get uname()
      {
        return this.form.get('uname');
      }
      get psw()
      {
        return this.form.get('psw');
      }


  ngOnInit(){
    this._services.getDoctor()
    .subscribe(data => this.details = data);
  }

  submit(form1 :{value:any;}) {
    console.log(form1.value);
  }

}
