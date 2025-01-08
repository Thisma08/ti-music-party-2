import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Music} from '../../../classes/music';
import {MusicService} from '../../../services/music.service';

@Component({
  selector: 'app-delete-music',
  standalone: true,
  imports: [],
  templateUrl: './delete-music.component.html',
  styleUrl: './delete-music.component.css'
})
export class DeleteMusicComponent {
  @Input() music!: Music;
  @Output() deletedMusic = new EventEmitter<Music>();

  constructor(private musicService: MusicService) {}

  deleteMusic(): void {
    this.musicService.deleteMusic(this.music.id).subscribe({
      next: () => {
        this.deletedMusic.emit(this.music);
      },
      error: (err) => {
        console.error('Error deleting music:', err);
      }
    });
  }

}
