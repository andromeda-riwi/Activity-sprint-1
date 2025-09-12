/**
 * Creating a sidebar enables you to:
 - create an ordered group of docs
 - render a sidebar for each doc of that group
 - share the same sidebar across docs
 - provide next/previous navigation

 The sidebars can be generated from the filesystem, or explicitly defined here.

 Create as many sidebars as you want.
 */

// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  tutorialSidebar: [
    {
      type: 'category',
      label: 'Documentación del Proyecto',
      items: [
        {
          type: 'doc',
          id: 'intro', // Apunta al archivo sprint-1.md
          label: 'Sprint 1 - Enunciado del Proyecto',
        },
        {
          type: 'doc',
          id: 'documentacion_tecnica', // Apunta al nuevo archivo de documentación técnica
          label: 'Documentación Técnica y Diagrama de Flujo',
        },
      ],
    },
    // Puedes agregar más categorías aquí si lo necesitas
  ],
};

export default sidebars;
