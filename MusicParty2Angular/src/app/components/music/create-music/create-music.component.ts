import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {MusicService} from '../../../services/music.service';
import {User} from '../../../classes/user';
import {UserService} from '../../../services/user.service';

@Component({
  selector: 'app-create-music',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './create-music.component.html',
  styleUrl: './create-music.component.css'
})
export class CreateMusicComponent implements OnInit {
  users: User[] = [];
  createMusicForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';
  serverErrors: any = {};

  constructor(private fb: FormBuilder, private musicService: MusicService, private userService: UserService) {
    this.createMusicForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      type: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      youtubeUrl: ['', [Validators.required, Validators.pattern(/^(https?:\/\/)?(www\.youtube\.com|youtu\.be)\/.+$/)],],
      userId: ['', [Validators.required]],
/*
      title: [''],
      type: [''],
      youtubeUrl: [''],
      userId: [''],
*/
    });
  }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.fetchAllUsers().subscribe((data: User[]) => {
      this.users = data;
    });
  }

  onSubmit(): void {
    if (this.createMusicForm.valid) {
      this.musicService.createMusic(this.createMusicForm.value).subscribe({
        next: (response) => {
          this.successMessage = 'Music created successfully!';
          this.createMusicForm.reset();
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

          if(err.errors) {
            this.serverErrors = err.errors;
          }
          console.log('Server errors:', this.serverErrors);
        },
      });
    }
  }
}
