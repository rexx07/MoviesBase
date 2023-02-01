import {Route} from "@angular/router";

export const PROFILE_ROUTES: Route[] = [
  {
    path: '',
    title: 'Profile',
    loadComponent: async () => (await import('./profile.component')).ProfileComponent,
  }
]
