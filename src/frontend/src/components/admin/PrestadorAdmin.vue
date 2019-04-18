<template>
    <div class="category-admin">
        <b-form>
            <input id="category-id" type="hidden" v-model="prestador.id" />
            <b-form-group label="Nome:" label-for="category-name">
                <b-form-input id="category-name" type="text"
                    v-model="prestador.nome" required
                    :readonly="mode === 'remove'"
                    placeholder="Informe o Nome do Prestador..." />
            </b-form-group>
            <b-form-group label="Latitude:" label-for="category-name">
                <b-form-input id="category-name" type="text"
                    v-model="prestador.latitude" required
                    :readonly="mode === 'remove'"
                    placeholder="Informe a Latitude do Prestador..." />
            </b-form-group>
            <b-form-group label="Longitude:" label-for="category-name">
                <b-form-input id="category-name" type="text"
                    v-model="prestador.longitude" required
                    :readonly="mode === 'remove'"
                    placeholder="Informe a Longitude do Prestador..." />
            </b-form-group>
            <b-form-group label="Horario:" label-for="category-name">
                <b-form-input id="category-name" type="text"
                    v-model="prestador.horario" required
                    :readonly="mode === 'remove'"
                    placeholder="Informe a Horario de funcionamento..." />
            </b-form-group>
            <b-form-group label="Telefone:" label-for="category-name">
                <b-form-input id="category-name" type="text"
                    v-model="prestador.telefone" required
                    :readonly="mode === 'remove'"
                    placeholder="Informe a Telefone do Prestador..." />
            </b-form-group>
            <b-button variant="primary" v-if="mode === 'save'"
                @click="save">Salvar</b-button>
            <b-button variant="danger" v-if="mode === 'remove'"
                @click="remove">Excluir</b-button>
            <b-button class="ml-2" @click="reset">Cancelar</b-button>
        </b-form>
        <hr>
        <b-table hover striped :items="prestadores" :fields="fields">
            <template slot="actions" slot-scope="data">
                <b-button variant="warning" @click="loadPrestador(data.item)" class="mr-2">
                    <i class="fa fa-pencil"></i>
                </b-button>
                <b-button variant="danger" @click="loadPrestador(data.item, 'remove')">
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
    name: 'PrestadorAdmin',
    data: function() {
        return {
            mode: 'save',
            prestador: {},
            prestadores: [],
            fields: [
                { key: 'id', label: 'Código', sortable: true },
                { key: 'nome', label: 'Nome', sortable: true },
                { key: 'latitude', label: 'Latitude', sortable: true },
                { key: 'longitude', label: 'Longitude' },
                { key: 'horario', label: 'Horario' },
                { key: 'telefone', label: 'Telefone' },
                { key: 'actions', label: 'Ações' }
            ]
        }
    },
    methods: {
        loadPrestadores() {
            const url = `${baseApiUrl}/api/Prestador`
            axios.get(url).then(res => {
                // this.categories = res.data
                this.prestadores = res.data.map(prestador => {
                    return { ...prestador, value: prestador.id, text: prestador.nome }
                })
            })
        },
        reset() {
            this.mode = 'save'
            this.prestador = {}
            this.loadPrestadores()
        },
        save() {
            const method = this.prestador.id ? 'put' : 'post'
            const id = this.prestador.id ? `/${this.prestador.id}` : ''
            axios[method](`${baseApiUrl}/api/Prestador${id}`, this.prestador)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        remove() {
            const id = this.prestador.id
            axios.delete(`${baseApiUrl}/api/Prestador/${id}`)
                .then(() => {
                    this.$toasted.global.defaultSuccess()
                    this.reset()
                })
                .catch(showError)
        },
        loadPrestador(prestador, mode = 'save') {
            this.mode = mode
            this.prestador = { ...prestador }
        }
    },
    mounted() {
        this.loadPrestadores()
    }
}
</script>

<style>

</style>