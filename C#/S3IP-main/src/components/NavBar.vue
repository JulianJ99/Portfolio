<template>
          <ul style="list-style-type: none;">
            <li v-if="!isAuthenticated && !isLoading" class="item">
              <button
                id="qsLoginBtn"
                class="btn btn-primary btn-margin"
                @click.prevent="login"
              >Login</button>
            </li>

            <li class="item dropdown" v-if="isAuthenticated">

                <img
                  :src="user.picture"
                  alt="User's profile picture"
                  class="user-profile rounded-circle"
                  width="50"
                />
              
              <div class="dropdown-menu dropdown-menu-right">
                <div class="dropdown-header">{{ user.name }}</div>
                <a id="qsLogoutBtn" href="#" class="dropdown-item" @click.prevent="logout">
                  <font-awesome-icon class="mr-3" icon="power-off" />Log out
                </a>
              </div>
            </li>
          </ul>
          <br />
</template>


<script>
import { useAuth0 } from '@auth0/auth0-vue';

export default {
  name: "LoginComponent",
  setup() {
    const { isAuthenticated, isLoading, user, loginWithRedirect, logout } = useAuth0();
    return {
      isAuthenticated,
      isLoading,
      user,
      login: () => {
        loginWithRedirect();
      },
      logout: () => {
        logout({
          returnTo: window.location.origin
        });
      }
    }
  }
};
</script>


<style>
#mobileAuthBar {
  min-height: 125px;
  justify-content: space-between;
}
.list{
    list-style-type: none;
}
</style>
