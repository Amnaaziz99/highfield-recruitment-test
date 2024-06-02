import { Component, OnInit } from '@angular/core';
import { HighfieldService } from '../../services/highfield.service';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  topColours: { colour: string, count: number }[] = [];
  ages: { userId: string, originalAge: number, agePlusTwenty: number }[] = [];

  constructor(private highfieldService: HighfieldService) { }

  ngOnInit(): void {
    this.highfieldService.getUsers().subscribe({
      next: (response) => {
        this.topColours = response.topColours;
        this.ages = response.ages;
      },
      error: (error) => {
      }
    });
  }
}