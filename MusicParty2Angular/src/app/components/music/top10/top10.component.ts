import {Component, OnInit} from '@angular/core';
import {Music} from '../../../classes/music';
import {MusicService} from '../../../services/music.service';
import {NgClass} from '@angular/common';
import {CreateVoteComponent} from '../../vote/create-vote/create-vote.component';
import {VoteService} from '../../../services/vote.service';

@Component({
  selector: 'app-top10',
  standalone: true,
  imports: [
    NgClass,
    CreateVoteComponent
  ],
  templateUrl: './top10.component.html',
  styleUrl: './top10.component.css'
})
export class Top10Component implements OnInit {
  musics: Music[] = [];
  voteCounts: Map<number, number> = new Map();

  constructor(private musicService: MusicService, private voteService: VoteService) {

  }

  ngOnInit(): void {
    this.loadMusics();
  }

  private loadMusics() {
    this.musicService.fetchTop10().subscribe((data: Music[]) => {
      this.musics = data;
      this.loadVoteCounts();
    });
  }

  private loadVoteCounts() {
    this.musics.forEach(music => {
      this.getVoteCount(music.id);
    });
  }

  getVoteCount(musicId: number | undefined): void {
    if (musicId === undefined) return;

    this.voteService.getVoteCount(musicId).subscribe({
      next: (response) => {
        const count = response.voteCount;
        this.voteCounts.set(musicId, count);
      },
      error: (err) => {
        console.error('Error fetching vote count', err);
      }
    });
  }

  onVoteAdded(): void {
    this.loadMusics();
  }
}
