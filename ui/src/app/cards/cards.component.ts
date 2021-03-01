import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  uname: any;
  psw: any;
  dataList: any;

  constructor(private service:SharedService) { }


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
}
