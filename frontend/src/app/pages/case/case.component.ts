import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '@services/api-service.service';
import { Case } from '@models/case.model';

@Component({
  selector: 'app-case',
  templateUrl: './case.component.html',
  styleUrl: './case.component.scss',
})
export class CaseComponent implements OnInit{
  cases: Case[] = [];

  constructor(
    private apiServiceService: ApiServiceService
  ) { }

  ngOnInit() {
    this.loadCases();
  }

  loadCases() {
    this.apiServiceService.getCases().subscribe(res => {
      this.cases = res;
    });
  }

}
