<template>
  <div>
    
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="email-input-group"
            label="Email address:"
            label-for="email-input"
            description="Enter your email.">
        <b-form-input id="email-input"
                      type="email"
                      v-model="form.email"
                      required
                      placeholder="person@domain.com"/>
      </b-form-group>                    

      <b-form-group id="password-input-group"
            label="Password:"
            label-for="password-input"
            description="Enter your password.">
        <b-form-input id="password-input"
                      type="password"
                      v-model="form.password"
                      required/>
      </b-form-group>

    </b-form>
  </div>
</template>
