import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  
  dataList: any;
  
  

  constructor(private service:SharedService) { 

    
  
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


  ngOnInit(): void {
  }

  loginCheck() {
    var val = {
      DocEmail: this.uname,
      DocPassword: this.psw
    };

    this.service.docLogin(val).subscribe(response => {
      this.dataList = Array.from(Object.keys(response), k => response[k]);
      console.log(this.dataList);
    },
      (error: Response) => {
        if (error.status === 404) {
          alert('No data found.');
        }
        else {
          alert('An unexpected error occured.');
          console.log(error);
        }
      }
    )
  }

  submit(form1 :{value:any;}) {
    console.log(form1.value);
  }

}
