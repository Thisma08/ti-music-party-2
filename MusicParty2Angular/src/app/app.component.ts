import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {CreateMusicComponent} from './components/music/create-music/create-music.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CreateMusicComponent, RouterLinkActive, RouterLink],
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MusicParty2Angular';
}
