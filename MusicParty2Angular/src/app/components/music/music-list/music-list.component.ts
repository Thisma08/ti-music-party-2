import {Component, OnInit} from '@angular/core';
import {Music} from '../../../classes/music';
import {MusicService} from '../../../services/music.service';
import {NgClass} from '@angular/common';
import {DeleteMusicComponent} from '../delete-music/delete-music.component';

@Component({
  selector: 'app-music-list',
  standalone:true,
  imports: [
    NgClass,
    DeleteMusicComponent
  ],
  templateUrl: './music-list.component.html',
  styleUrl: './music-list.component.css'
})
export class MusicListComponent implements OnInit {
  musics: Music[] = [];

  constructor(private musicService: MusicService) {}

  ngOnInit(): void {
    this.loadMusics();
  }

  private loadMusics() {
    this.musicService.fetchAllMusics().subscribe((data: Music[]) => {
      this.musics = data;
    });
  }

  openInYoutube(url: string): void {
    window.open(url, '_blank');
  }

  onMusicDeleted(songToDelete: Music): void {
    this.musics = this.musics.filter(music => music.id !== songToDelete.id);
  }
}
