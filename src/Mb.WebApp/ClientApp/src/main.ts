import {environment} from "./environments/environment";
import {enableProdMode, importProvidersFrom} from "@angular/core";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {bootstrapApplication} from "@angular/platform-browser";
import {AppComponent} from "./app/app.component";
import {routes} from "./app/app.routes";
import {AuthService, JwtInterceptor, ServerErrorInterceptor, ThemeService} from "./app/core";
import {provideRouter} from "@angular/router";

if (environment.production)
  enableProdMode();

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    importProvidersFrom(HttpClientModule),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
      provide: AuthService,
      useClass: AuthService
    },
    {
      provide: ThemeService,
      useClass: ThemeService
    }
  ],
}).catch(err => console.error(err));
