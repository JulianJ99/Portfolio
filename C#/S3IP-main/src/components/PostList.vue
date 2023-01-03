<template>
    <ul v-for="post in posts" :key="post.id">

        <table cellpadding="0" cellspacing="0" class="center" aria-describedby="Table for post from database">
          
        <th>

        </th>
        <tr>
          <td style="width: 150px">{{post.username}}</td>
        </tr>

        <tr>
          <td style="width: 150px"><img :src=post.userimage style="max-width:100px" alt="User's profile picture"></td>
        </tr>

        <tr>
          <td style="width: 150px">{{post.post}}</td>
        </tr>

        <tr>
          <td style="width: 150px">
            <iframe :src=post.song width="250" height="80"  allowtransparency="true" allow="encrypted-media" title="spotify link"></iframe>
          </td>
        </tr>
    </table>
    </ul>
</template>

<script>
import PostDataService from "../services/PostsDataServices";
export default {
  name: "posts-list",
  data() {
    return {
      posts: []
    };
  },
  methods: {
    retrievePosts() {
      PostDataService.getAll()
        .then(response => {
          this.posts = response.data;
          console.log(response.data);
          console.log(this.posts);
        })
        .catch(e => {
          console.log(e);
        });
    },
  },
  created() {
    this.retrievePosts();
  }
};
</script>
<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
  list-style-type: none;
}
</style>