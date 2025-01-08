import { Routes } from '@angular/router';
import {CreateMusicComponent} from './components/music/create-music/create-music.component';
import {MusicListComponent} from './components/music/music-list/music-list.component';
import {CreateVoteComponent} from './components/vote/create-vote/create-vote.component';
import {Top10Component} from './components/music/top10/top10.component';

export const routes: Routes = [
  {path: 'create-music', component: CreateMusicComponent},
  {path: 'music-list', component: MusicListComponent},
  {path: 'create-vote', component: CreateVoteComponent},
  {path: 'top10', component: Top10Component}



];
