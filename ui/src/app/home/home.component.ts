import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 
  doctor=[
    {
      title:"Search Patients",
      'url':'/welcome/search-patients'

    },
    {
      title:"Allot Rooms",
      'url':""
    },
    {
      title:"Add Patient",
      'url':""
    }

  ];

  patient=[{
    title:'Search Doctor',
    'url':""
  },
  {
    title:'Check Report',
    'url':""
  },
  {
    title:'Room number',
    'url':""
  }
];
  public person: Params | undefined;
    show: {
        title: string;
        url: string;
    }[] | undefined;
  constructor(private _route: Router,private _router:ActivatedRoute) { }

 
  ngOnInit(): void {
    this.person= this._router.snapshot.queryParams.person;
    console.log(this._router.snapshot.queryParams.person)

    if (this._router.snapshot.queryParams.person == "doctor") {

      this.show=this.doctor;
      
    }
    else{
      this.show= this.patient;
    }
  }

  searchPatients()
  {
    this._route.navigate(['/welcome/search-patients'])
}

}
