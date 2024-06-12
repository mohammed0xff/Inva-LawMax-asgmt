import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '@services/api-service.service';
import { Hearing } from '@models/hearing.model';

@Component({
  selector: 'app-hearing',
  templateUrl: './hearing.component.html',
  styleUrl: './hearing.component.scss',
})
export class HearingComponent implements OnInit {
  hearings: Hearing[] = [];

  constructor(
    private apiServiceService: ApiServiceService
  ) { }

  ngOnInit() {
    this.loadHearings();
  }

  loadHearings() {
    this.apiServiceService.getHearings().subscribe(res => {
      this.hearings = res;
    });
  }
}