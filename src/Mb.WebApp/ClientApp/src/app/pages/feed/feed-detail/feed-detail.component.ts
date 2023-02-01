import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {CommonModule} from '@angular/common';
import {IContent, IMovie, ITV} from "../interfaces";
import {ImgMissingDirective, PaginationModel, SeoService} from "../../../core";
import {MoviesService, OnTvService} from "../services";
import {ActivatedRoute, Router} from "@angular/router";
import {DomSanitizer} from "@angular/platform-browser";
import {MatDialog, MatDialogModule} from "@angular/material/dialog";
import {take} from "rxjs";
import {MatProgressBarModule} from "@angular/material/progress-bar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {PosterCardComponent} from "../../../components";
import {CdkDrag, CdkDragHandle} from "@angular/cdk/drag-drop";

@Component({
  selector: 'app-feed-detail',
  standalone: true,
  imports: [
    CommonModule,
    MatProgressBarModule,
    ImgMissingDirective,
    MatIconModule,
    MatButtonModule,
    PosterCardComponent,
    CdkDrag,
    CdkDragHandle,
    MatDialogModule
  ],
  templateUrl: './feed-detail.component.html',
  styleUrls: ['./feed-detail.component.scss']
})
export class FeedDetailComponent implements OnInit {
  contentType = '';
  movieContent!: Partial<IMovie>;
  tvShowContent!: Partial<ITV>;
  recommendedContentList: Array<PaginationModel> = [];
  video!: IContent | any;
  isLoading: boolean = true;

  @ViewChild('matTrailerDialog') matTrailerDialog!: TemplateRef<any>;

  constructor(
    private moviesService: MoviesService,
    private tvShowsService: OnTvService,
    private route: ActivatedRoute,
    private router: Router,
    private sanitizer: DomSanitizer,
    private seoService: SeoService,
    public trailerDialog: MatDialog
  ) {
    this.contentType = this.router.url.split('/')[1];
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      params => {
        const id = params['url'];

        if (this.contentType === 'movies') {
          this.getMovie(id);
          this.getMovieVideo(id);
          this.getRecommendedMovie(id);
        } else {
          this.getTvShow(id);
          this.getTvShowVideo(id);
          this.getRecommendedTvShow(id);
        }
      }
    );
  }


  getMovie(id: string) {
    this.isLoading = true;

    this.moviesService.getMovie(id).pipe(take(1)).subscribe(
      movie => {
        this.movieContent = movie;
        this.generateMovieSeo()
        this.isLoading = false;
      }
    );
  }

  getMovieVideo(id: string) {
    this.moviesService.getMovieVideos(id).pipe(take(1)).subscribe(
      res => {
        if (res?.results?.length > 0) {
          const trailerList = res.results.filter((video: any) => video.type === 'Trailer');
          this.video = trailerList[0];
          this.video['url'] = this.sanitizer.bypassSecurityTrustResourceUrl('https://www.youtube.com/embed/' +
            this.video['key']);
        } else
          this.video = null;
      }, () => {
      }
    );
  }

  getRecommendedMovie(id: string) {
    this.moviesService.getRecommendMovies(id).pipe(take(1)).subscribe(
      res => {
        this.recommendedContentList = res.results.slice(0, 12);
      }, () => {
      }
    );
  }

  getTvShow(id: string) {
    this.isLoading = true;

    this.tvShowsService.getTVShow(id).pipe(take(1)).subscribe(
      tvShow => {
        this.tvShowContent = tvShow;
        this.generateTvShowSeo();
        this.isLoading = false;
      }
    );
  }

  getTvShowVideo(id: string) {
    this.tvShowsService.getTVShowVideos(id).pipe(take(1)).subscribe(
      res => {
        if (res?.results?.length > 0) {
          this.video = res.results.filter((video: any) => video.type === 'Trailer')[0];
          this.video['url'] = this.sanitizer.bypassSecurityTrustResourceUrl('https://www.youtube.com/embed/'
            + this.video['key']);
        } else
          this.video = null;
      }, () => {
      }
    );
  }

  getRecommendedTvShow(id: string) {
    this.tvShowsService.getRecommendTVShows(id).pipe(take(1)).subscribe(
      res => {
        this.recommendedContentList = res.results.slice(0, 12);
      }, () => {
      }
    );
  }

  generateMovieSeo() {
    this.seoService.generateTags({
      title: `${this.movieContent.title}`,
      description: `${this.movieContent.overview}`,
      image: `https://image.tmdb.org/t/p/w780/${this.movieContent.backdrop_path}`,
      slug: 'movie'
    });
  }

  generateTvShowSeo() {
    this.seoService.generateTags({
      title: `${this.tvShowContent.name}`,
      description: `${this.tvShowContent.overview}`,
      image: `https://image.tmdb.org/t/p/w780/${this.tvShowContent.backdrop_path}`,
      slug: 'movie'
    });
  }

  openDialog(): void {
    const dialogRef = this.trailerDialog.open(this.matTrailerDialog, {});
    dialogRef.disableClose = false;
  }
}
