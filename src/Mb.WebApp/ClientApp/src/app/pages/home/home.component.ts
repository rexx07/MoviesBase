import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import SwiperCore, {Pagination, SwiperOptions} from 'swiper';
import {take} from "rxjs";
import {RouterLink} from "@angular/router";
import {MatIconModule} from "@angular/material/icon";
import {MatTabsModule} from "@angular/material/tabs";
import {SwiperModule} from "swiper/angular";
import {PosterCardComponent} from "../../components/poster-card/poster-card.component";
import {SeoService} from "../../core";
import {MovieModel, MoviesService, OnTvService, TvModel} from "../feed";

SwiperCore.use([Pagination])

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterLink, MatIconModule, MatTabsModule, SwiperModule, PosterCardComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  config: SwiperOptions = {
    slidesPerView: 2.3,
    spaceBetween: 20,
    navigation: true,
    watchSlidesProgress: true,
    grabCursor: true,
    pagination: {clickable: true},
    scrollbar: {draggable: true},
    breakpoints: {
      992: {slidesPerView: 6.3, spaceBetween: 20, slidesOffsetBefore: 0, slidesOffsetAfter: 0},
      768: {slidesPerView: 4.3, spaceBetween: 15, slidesOffsetBefore: 0, slidesOffsetAfter: 0},
      576: {slidesPerView: 3.3, spaceBetween: 15, slidesOffsetBefore: 0, slidesOffsetAfter: 0},
      320: {slidesPerView: 2.3, spaceBetween: 10, slidesOffsetBefore: 10, slidesOffsetAfter: 10},
    }
  };

  movieTabList = ['Now playing', 'Upcoming', 'Popular'];
  movieList: Array<MovieModel> = [];
  selectMovieTab = 0;

  tvShowsTabList = ['Airing Today', 'Currently Airing', 'Popular'];
  tvShowsList: Array<TvModel> = [];
  selectedTvTab = 0;

  constructor(
    private movieService: MoviesService,
    private onTvService: OnTvService,
    private seoService: SeoService
  ) {
  }

  ngOnInit() {
    this.seoService.generateTags({
      title: 'Movies Base ans Series',
      description: 'Movies and series homepage',
      image: 'https://jancobh.github.io/Angular-Movies/background-main.jpg'
    });

    this.getMovies('now_playing', 1);
    this.getTvShows('airing_today', 1);
  }

  tabChange(event: any) {
    this.selectMovieTab = event.index;
    if (event.index === 0) {
      this.getMovies('now_playing', 1);
    } else if (event.index === 1) {
      this.getMovies('upcoming', 1);
    } else if (event.index === 2) {
      this.getMovies('popular', 1);
    }
  }

  tabTvChange(event: any) {
    this.selectedTvTab = event.index;
    if (event.index === 0) {
      this.getTvShows('airing_today', 1);
    } else if (event.index === 1) {
      this.getTvShows('on_the_air', 1);
    } else if (event === 2) {
      this.getTvShows('popular', 1);
    }
  }

  getMovies(type: string, page: number): void {
    this.movieService.getMovies(type, page).pipe(take(1)).subscribe(res => {
      this.movieList = res.result;
    });
  }

  getTvShows(type: string, page: number): void {
    this.onTvService.getTVShows(type, page).subscribe(res => {
      this.tvShowsList = res.results;
    });
  }
}
