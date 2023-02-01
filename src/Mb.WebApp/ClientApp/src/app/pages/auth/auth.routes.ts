import {Route} from "@angular/router";

export const AUTH_ROUTES: Route[] = [
  {
    path: '',
    title: 'Login',
    loadComponent: async () => (await import('./login/login.component')).LoginComponent,
  },
  {
    path: 'register',
    title: 'Register',
    loadComponent: async () => (await import('./register/register.component')).RegisterComponent,
  }
];
