import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service'
import { LoginService } from '../login.service';

@Component({
  selector: 'cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  public details: import("src/app/doctor").IDoctor[] | undefined;
  public person:string="";
  

  constructor(private _router: Router,private _services:LoginService) { 

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

      change1(){

        this.person = 'doctor';
      }
    
      change2(){
        this.person = 'patient';
      }
    

  ngOnInit(){
    this._services.getDoctor()
    .subscribe(data => this.details = data);


    
  }

  submit(form1 :{value:any;}) {
    console.log(form1.value);
    console.log(this.person);
    this._router.navigate(['/welcome'],{
      queryParams: {'person':this.person }
    });
  }
  
}
