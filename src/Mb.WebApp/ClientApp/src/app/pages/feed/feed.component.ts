import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {PaginationModel} from "../../core";
import {MoviesService, OnTvService} from "./services";
import {Router} from "@angular/router";
import {take} from "rxjs";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {PosterCardComponent} from "../../components/poster-card/poster-card.component";
import {MatPaginatorModule} from "@angular/material/paginator";

@Component({
  selector: 'app-feed',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, PosterCardComponent, MatPaginatorModule],
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {
  contentType = '';
  nowPlaying: Array<PaginationModel> = [];

  totalResults: number = 0;

  constructor(
    private moviesService: MoviesService,
    private tvShowsService: OnTvService,
    private router: Router
  ) {
    this.contentType = this.router.url.split('/')[1];
  }

  ngOnInit() {
    if (this.contentType === 'movies')
      this.getNowPlayingMovies(1);
    else
      this.getNowPlayingTVShows(1);
  }

  getNowPlayingMovies(page: number) {
    this.moviesService.getNowPlaying(page).pipe(take(1)).subscribe(
      res => {
        this.totalResults = res.totalResults;
        this.nowPlaying = res.results;
      }, () => {
      }
    );
  }

  getNowPlayingTVShows(page: number) {
    this.tvShowsService.getTvOnTheAir(page).pipe(take(1)).subscribe(
      res => {
        this.totalResults = res.total_results;
        this.nowPlaying = res.results;
      }, () => {
      }
    );
  }

  changePage(event: any) {
    if (this.contentType === 'movies')
      this.getNowPlayingMovies(event.pageIndex + 1);
    else
      this.getNowPlayingTVShows(event.pageIndex + 1);
  }
}
