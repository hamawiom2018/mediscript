import { Component, OnInit } from '@angular/core';
import { Visit, visitsVar } from 'src/models/visit.model';

@Component({
  selector: 'app-visits-page',
  templateUrl: './visits-page.component.html',
  styleUrls: ['./visits-page.component.css']
})
export class VisitsPageComponent implements OnInit {
  visits: Visit[]=visitsVar;
  ngOnInit(): void {

  }
  
}
