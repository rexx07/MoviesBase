import {Component, EventEmitter, HostListener, Output} from '@angular/core';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import {themeColors} from "../../constants/them-colors";
import {Color} from "../../enums/colors.enum";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {MatButtonModule} from "@angular/material/button";
import {MatMenuModule} from "@angular/material/menu";
import {MatIconModule} from "@angular/material/icon";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink, NgOptimizedImage, MatButtonModule, RouterLinkActive, MatMenuModule, MatIconModule],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @Output() changeColorTheme: EventEmitter<string> = new EventEmitter();

  themeColorList = themeColors;
  themeColorInit: string = Color.RED;

  isScrolled = false;

  constructor() {
  }

  @HostListener('window:scroll')
  scrollEvent() {
    this.isScrolled = window.scrollY >= 30;
  }

  setColorTheme(color: string) {
    this.themeColorInit = color;
    this.changeColorTheme.emit(color);
  }
}
