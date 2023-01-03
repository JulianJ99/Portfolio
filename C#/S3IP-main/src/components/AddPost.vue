<template>

  <div class="submit-form" v-if="isAuthenticated">

    <div v-if="!submitted">
      <div class="form-group">
        <label for="post">Post</label>
        <input
          type="text"
          class="form-control"
          id="post"
          required
          v-model="post.post"
          name="post"
        />
      </div>

      <div class="form-group">
        <label for="song">Song</label>
        <input
          type="text"
          class="form-control"
          id="song"
          required
          v-model="post.song"
          name="song"
        />
      </div>

      <button @click="savePost" class="btn btn-success">Submit</button>
    </div>

    <div v-else>
      <h4>You submitted successfully!</h4>
      <button class="btn btn-success" @click="newPost">Add</button>
    </div>
  </div>
</template>

<script>
import PostDataService from "../services/PostsDataServices.js";
import { useAuth0 } from '@auth0/auth0-vue';
export default {
  setup(){
  const { user, isAuthenticated } = useAuth0();
  return {
      user, isAuthenticated
    }
  },
  name: "add-post",
  data() {

    return {
      post: {
        id: null,
        post: "",
        song: "",
        username: "",
        userimage: "",
      },
      submitted: false
    };

  },

  methods: {

    savePost() {
      if(this.post.post === "" || this.post.song === ""){
        console.log("no.")
        alert("Post or Song is empty")
      }
      else{
        var data = {
        post: this.post.post,
        song: this.post.song,
        username: this.user.name,
        userimage: this.user.picture,
      };
      PostDataService.create(data)
        .then(response => {
          this.post.id = response.data.id;
          console.log(response.data);
          this.submitted = true;
          location.reload();
        })
        .catch(e => {
          console.log(e);
        });
      }

    },
    
    newPost() {
      this.submitted = false;
      this.post = {};
    }

  }
};
</script>
<style>
.submit-form {
  max-width: 300px;
  margin: auto;
}
</style>