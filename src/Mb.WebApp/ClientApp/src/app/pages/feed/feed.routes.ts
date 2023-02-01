import {Route} from "@angular/router";
import {MoviesService, OnTvService} from "./services";

export const FEED_ROUTES: Route[] = [
  {
    path: '',
    title: 'Title',
    loadComponent: async () => (await import('./feed.component')).FeedComponent,
    providers: [
      MoviesService,
      OnTvService
    ]
  },
  {
    path: 'feed-detail',
    title: 'Feed-Detail',
    loadChildren: async () => (await import('./feed-detail')).FEED_DETAIL_ROUTES
  }
]
