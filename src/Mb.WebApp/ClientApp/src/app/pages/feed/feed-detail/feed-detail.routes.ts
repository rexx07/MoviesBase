import {Route} from "@angular/router";

export const FEED_DETAIL_ROUTES: Route[] = [
  {
    path: '',
    title: 'Feed Detail',
    loadComponent: async () => (await import('./feed-detail.component')).FeedDetailComponent
  }
]
