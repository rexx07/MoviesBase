import {Component, Inject, OnInit, PLATFORM_ID} from '@angular/core';
import {isPlatformBrowser, NgClass} from "@angular/common";
import {NavigationEnd, Router, RouterOutlet} from "@angular/router";
import {Color, FooterComponent, NavbarComponent, themeColors} from "./core";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [
    RouterOutlet,
    NgClass,
    NavbarComponent,
    FooterComponent
  ],
  standalone: true
})
export class AppComponent implements OnInit {
  themColorList = themeColors;
  themeColorEnum = Color;
  themeColorInit: string = Color.RED;

  private isBrowser: boolean = isPlatformBrowser(this.platformId);

  constructor(
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: any
  ) {
  }

  ngOnInit(): void {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd))
        return;
      if (this.isBrowser)
        window.scrollTo(0, 0);
    });
  }

  changeColorTheme(color: string): void {
    this.themeColorInit = color;
  }

  checkSelectedTheme(color: string) {
    return this.themeColorInit === color;
  }
}
