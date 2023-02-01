import {Route} from "@angular/router";
import {MoviesService, OnTvService} from "../feed";
import {SeoService} from "../../core";

export const HOME_ROUTES: Route[] = [
  {
    path: '',
    title: 'Home',
    providers: [
      MoviesService,
      OnTvService,
      SeoService
    ],
    loadComponent: async () => (await import('./home.component')).HomeComponent
  }
]
