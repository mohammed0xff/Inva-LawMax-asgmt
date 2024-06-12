import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '@services/api-service.service';
import { Lawyer } from '@models/lawyer.model';

@Component({
  selector: 'app-lawyer',
  templateUrl: './lawyer.component.html',
  styleUrl: './lawyer.component.scss',
  providers: [ApiServiceService] 
})
export class LawyerComponent implements OnInit {
  lawyers: Lawyer[] = [];

  constructor(private apiServiceService: ApiServiceService) { }

  ngOnInit() {
    this.loadLawyers();
  }

  loadLawyers() {
    this.apiServiceService.getLawyers().subscribe(res => {
      this.lawyers = res;
    });
  }

}
