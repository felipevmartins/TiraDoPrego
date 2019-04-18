<template>
    <div class="user-admin">
        <b-form>
            <input id="user-id" type="hidden" v-model="usuarioEdit.id" />
            <b-row>
                <b-col md="6" sm="12">
                    <b-form-group label="Nome:" label-for="user-name">
                        <b-form-input id="user-name" type="text"
                            v-model="usuarioEdit.login" required
                            :readonly="mode === 'remove'"
                            placeholder="Informe o Login do Usuário..." />
                    </b-form-group>
                </b-col>
            </b-row>
           <b-row>
                <b-col md="6" sm="12">
                    <b-form-group label="Email:" label-for="user-email">
                        <b-form-input id="user-email" type="text"
                            v-model="usuarioEdit.email" required
                            :readonly="mode === 'remove'"
                            placeholder="Informe o Email do Usuário..." />
                    </b-form-group>
                </b-col>
            </b-row>
            <b-row v-show="mode === 'save'">
                <b-col md="6" sm="12">
                    <b-form-group label="Senha:" label-for="user-password">
                        <b-form-input id="user-password" type="password"
                            v-model="usuarioEdit.password" required
                            placeholder="Informe a Senha do Usuário..." />
                    </b-form-group>
                </b-col>
                
            </b-row>
            <b-row>
                <b-col xs="12">
                    <b-button variant="primary" v-if="mode === 'save'"
                        @click="save">Salvar</b-button>
                    <b-button variant="danger" v-if="mode === 'remove'"
                        @click="remove">Excluir</b-button>
                    <b-button class="ml-2" @click="reset">Cancelar</b-button>
                </b-col>
            </b-row>
        </b-form>
        <hr>
        <b-table hover striped :items="usuarios" :fields="fields">
            <template slot="actions" slot-scope="data">
                <b-button variant="warning" @click="loadUsuario(data.item)" class="mr-2">
                    <i class="fa fa-pencil"></i>
                </b-button>
                <b-button variant="danger" @click="loadUsuario(data.item, 'remove')">
                    <i class="fa fa-trash"></i>
                </b-button>
            </template>
        </b-table>
    </div>
</template>

<script>
import { baseApiUrl, showError } from '@/global'
import axios from 'axios'

export default {
    name: 'UsuarioAdmin',
    data: function() {
        return {
            mode: 'save',
            usuarioEdit: {},
            usuarios: [],
            fields: [
                { key: 'id', label: 'Código', sortable: true },
                { key: 'login', label: 'Login', sortable: true },
                { key: 'email', label: 'Email', sortable: true },
                { key: 'actions', label: 'Ações' }
            ]
        }
    },
    methods: {
        loadUsuarios() {
            const url = `${baseApiUrl}/api/Usuario`
            axios.get(url).then(res => {
                this.usuarios = res.data
            })
        },
        reset() {
            this.mode = 'save'
            this.usuarioEdit = {}
            this.loadUsuarios()
        },
        save() {
            const method = this.usuarioEdit.id ? 'put' : 'post'
            const id = this.usuarioEdit.id ? `/${this.usuarioEdit.id}` : ''
            axios[method](`${baseApiUrl}/api/Usuario${id}`, this.usuarioEdit)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        remove() {
            const id = this.usuarioEdit.id
            axios.delete(`${baseApiUrl}/api/Usuario/${id}`)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        loadUsuario(usuarioEdit, mode = 'save') {
            this.mode = mode
            this.usuarioEdit = { ...usuarioEdit }
        }
    },
    mounted() {
        this.loadUsuarios()
        this.usuarioEdit = {}
        console.log(this.usuarioEdit)
    }
}
</script>

<style>

</style>
