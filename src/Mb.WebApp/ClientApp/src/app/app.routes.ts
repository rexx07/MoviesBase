import {Routes} from "@angular/router";

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'auth',
    loadChildren: async () => (await import('./pages/auth')).AUTH_ROUTES
  },
  {
    path: 'home',
    loadChildren: async () => (await import('./pages/home')).HOME_ROUTES
  },
  {
    path: 'profile',
    loadChildren: async () => (await import('./pages/profile')).PROFILE_ROUTES,
  },
  {
    path: 'movies',
    loadChildren: async () => (await import('./pages/feed')).FEED_ROUTES
  },
  {
    path: 'tv-shows',
    loadChildren: async () => (await import('./pages/feed')).FEED_ROUTES
  },
  {
    path: '404',
    pathMatch: 'full',
    loadComponent: async () => (await import('./components')).NotFoundComponent
  },
  {
    path: '**',
    redirectTo: '404'
  }
]
