import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Actors} from "./models/actors";
import {MovieModel, MoviesService} from "../feed";
import {ActivatedRoute} from "@angular/router";
import {MatCardModule} from "@angular/material/card";
import {MatTabsModule} from "@angular/material/tabs";
import {MatIconModule} from "@angular/material/icon";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatTabsModule,
    MatIconModule
  ]
})
export class ProfileComponent implements OnInit {
  person: Actors = new Actors();
  movies: MovieModel = new MovieModel();
  externalIds: Object = {};

  constructor(
    private moviesService: MoviesService,
    private router: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.externalIds = {
      twitter_id: "rexx07",
      instagram_id: "rexx07",
      facebook_id: "rexx07"
    }

    this.router.params.subscribe((params) => {
      const id = params['id'];
      this.moviesService.getPersonDetail(id).subscribe(person => {
        this.person = person;
      }, error => console.log(error));
      this.moviesService.getPersonCast(id).subscribe(res => {
        this.movies = res.cast;
      }, error => console.log(error));

      this.moviesService.getPersonExternalData(id).subscribe(res => {
        this.externalIds = res;
      }, error => console.log(error));
    });
  }
}
