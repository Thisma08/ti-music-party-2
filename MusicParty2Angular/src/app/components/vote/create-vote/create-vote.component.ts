import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MusicService} from '../../../services/music.service';
import {Music} from '../../../classes/music';
import {User} from '../../../classes/user';
import {VoteService} from '../../../services/vote.service';
import {UserService} from '../../../services/user.service';

@Component({
  selector: 'app-create-vote',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './create-vote.component.html',
  styleUrl: './create-vote.component.css'
})
export class CreateVoteComponent implements OnInit {
  @Output() addedVote = new EventEmitter<void>();

  users: User[] = [];
  musics: Music[] = [];
  successMessage: string = '';
  errorMessage: string = '';
  selectedUserId!: number;
  selectedMusicId!: number;

  constructor(
    private voteService: VoteService,
    private musicService: MusicService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.loadUsers();
    this.loadMusics();
  }

  loadUsers(): void {
    this.userService.fetchAllUsers().subscribe((data: User[]) => {
      this.users = data;
    });
  }

  loadMusics(): void {
    this.musicService.fetchAllMusics().subscribe((data: Music[]) => {
      this.musics = data;
    });
  }

  addVote(): void {
    if (this.selectedUserId && this.selectedMusicId) {
      this.voteService.createVote(this.selectedUserId, this.selectedMusicId).subscribe({
        next: (response) => {
          this.successMessage = 'Vote added successfully!';
          this.addedVote.emit();
          setTimeout(() => {
            this.successMessage = '';
          }, 5000);
        },
        error: (err) => {
          if(err.message) {
            this.errorMessage = err.message;
          }
          else {
            this.errorMessage = 'An unexpected error occurred.';
          }
          setTimeout(() => {
            this.errorMessage = '';
          }, 5000);
        },
      });
    }
  }
}
